import React, { Component } from 'react';
import { StyleSheet, View, Text, FlatList, SafeAreaView } from 'react-native';
import { purple, white } from '../utils/colors';
import DeckItem from './DeckItem';
import { connect } from 'react-redux';
import { getDecks } from '../actions/index';
import { setLocalNotification } from '../utils/helpers';

class Decks extends Component {
	renderDecks = () => {
		if (this.props.decks.length === 0) {
			return (
				<View style={styles.centered}>
					<Text style={styles.message}>You don't have any decks. Why not create one?</Text>
				</View>
			);
		} else {
			return (
				<SafeAreaView style={styles.container}>
					<FlatList
						data={this.props.decks}
						renderItem={({ item }) => {
							return (
								<DeckItem
									title={item.title}
									noOfCards={item.noOfCards}
									showDetail={() => this.showDetail(item.title)}
								/>
							);
						}}
						keyExtractor={(item) => item.index}
					/>
				</SafeAreaView>
			);
		}
	};

	showDetail = (id) => {
		this.props.navigation.navigate('DeckDetail', { id });
	};

	componentDidMount() {
		this.props.dispatch(getDecks());
		setLocalNotification();
	}
	render() {
		return (
			<View style={styles.container}>
				<View style={styles.column}>{this.renderDecks()}</View>
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'flex-start'
	},
	column: {
		flexDirection: 'column',
		flex: 1
	},
	message: {
		fontSize: 20,
		justifyContent: 'center',
		alignContent: 'center',
		textAlign: 'center'
	},
	centered: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'center'
	}
});

function mapStateToProps(state) {
	let decks = [];
	let index = 0;
	for (let [ key ] of Object.entries(state)) {
		const noOfCards =
			state[key].questions ? state[key].questions.length :
			0;
		decks.push({ index: index.toString(), title: state[key].title, noOfCards });
		index = index + 1;
	}
	decks = decks.sort((a, b) => b.noOfCards - a.noOfCards);
	return { decks };
}

export default connect(mapStateToProps)(Decks);
